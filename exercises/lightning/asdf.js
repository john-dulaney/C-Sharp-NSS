const fs = require('fs');

const scrape = require('scrape-it');
const _ = require('lodash');


// Weeks 1-15 and 'P' (for postseason?)
const weeks = [
    '01', '02', '03', '04',
    '05', '06', '07', '08',
    '09', '10', '11', '12',
    '13', '14', '15', 'P',
];

// Scrape the data we care about
const scrapeWeek = week => scrape(
        `http://www.ncaa.com/scoreboard/football/fbs/2017/${week}`, {
            games: {
                listItem: 'section.game.final',
                data: {
                    teams: {
                        listItem: '.linescore .team a',
                    },
                    scores: {
                        listItem: '.linescore .final.score',
                    }
                }
            }
        }
    )
    .then(data => data.games);


// Clean up the games and toss them into one big array
Promise.all(weeks.map(scrapeWeek))
    .then(weeks => _.flatten(weeks))
    .then(games => games.map(game => {
        const [away, home] = game.teams;
        const [awayScore, homeScore] = game.scores.map(parseFloat);

        const winner = (homeScore > awayScore) ? 'home' : 'away';

        return {
            home,
            away,
            winner
        };
    }))
    .then(JSON.stringify)
    .then(data => fs.writeFileSync('games.json', data));
one - true - champion.js:
    const fs = require('fs');

const _ = require('lodash');
const graphSequencer = require('graph-sequencer');


const {
    flatten,
    get,
    groupBy,
    mapValues,
    map,
    sortBy,
    uniqBy,
} = _;


// WHY NCAA?? WHY????
// It wasn't the hardest, but this might be the most tedious
// part of this whole project. (Note that most of these
// aliases were used for only 1 game!)
const aliases = {
    'C MICH': 'Cent. Michigan',
    PITT: 'Pittsburgh',
    GATECH: 'Georgia Tech',
    TENN: 'Tennessee',
    WASHST: 'Washington St.',
    BOISE: 'Boise State',
    IOWAST: 'Iowa State',
    IOWA: 'Iowa',
    TEXAS: 'Texas',
    'TX A&M': 'Texas A&M',
    ARK: 'Arkansas',
    'S ALA': 'South Alabama',
    IDAHO: 'Idaho',
    'E MICH': 'Eastern Mich.',
    OHIO: 'Ohio',
    ULL: 'Louisiana',
    'LA MON': 'La.-Monroe',
    WYO: 'Wyoming',
    HAWAII: 'Hawaii',
    BUFF: 'Buffalo',
    'W MICH': 'Western Mich.',
    'KAN ST': 'Kansas St.',
    IND: 'Indiana',
    MICH: 'Michigan',
    OKLAST: 'Oklahoma State',
    NWSTRN: 'Northwestern',
    ARMY: 'Army West Point',
    TEMPLE: 'Temple',
    CINCY: 'Cincinnati',
    CHAR: 'Charlotte',
    LATECH: 'Louisiana Tech',
    'S MISS': 'Southern Miss',
    CAL: 'California',
    ARIZ: 'Arizona',
    NIU: 'Northern Ill.',
    MICHST: 'Mich. St.',
    UMASS: 'Massachusetts',
    'APP ST': 'Appalachian St.',
    TXTECH: 'Texas Tech',
    NEB: 'Nebraska',
    'E CAR': 'East Carolina',
    TULANE: 'Tulane',
    'CO ST': 'Colorado State',
    'W KY': 'Western Ky.',
    MIDTEN: 'Middle Tenn.',
    MEM: 'Memphis',
    'NM ST': 'New Mexico St.',
    'UT ST': 'Utah State',
    OKLA: 'Oklahoma',
    UGA: 'Georgia',
};


// `games.json` is created by `download.js`
const games = require('./games.json')
    .map(game => {
        return {
            home: get(aliases, game.home, game.home),
            away: get(aliases, game.away, game.away),
            winner: game.winner,
        };
    });


// Group games by the teams participating
const gamesByTeam = games.reduce((byTeam, game) => {
    const {
        home,
        away
    } = game;

    const addGame = team => get(byTeam, team, []).concat(game);

    return {
        ...byTeam,
        [home]: get(byTeam, home, []).concat(game),
        [away]: get(byTeam, away, []).concat(game),
    };
}, {});



const teams = Object.values(
        mapValues(gamesByTeam, (teamGames, name) => {
            const wins = teamGames
                .filter(game => game[game.winner] === name);

            return {
                name,
                wins,
                winningPercentage: wins.length / teamGames.length,
                games: teamGames,
            };
        })
    )
    // Exclude teams that only show up a few times –
    // this is roughly a proxy for FCS teams
    .filter(team => team.games.length > 4);


// For each team, get a pair of [name, [...teams_defeated]]
const defeatedOpponentsByTeam = new Map(
    teams
    .map(team => [
        team.name,
        team.wins.map(game => {
            const loser = game.winner === 'home' ? 'away' : 'home';
            return game[loser];
        })
    ])
);


// Group teams by their winning percentage
const teamsByWinningPercentage = mapValues(
    groupBy(
        teams,
        team => Math.round(team.winningPercentage * 1000)
    ),
    group => group.map(team => team.name)
);


// Set priority groups by winning percentage
const groups = map(
    sortBy(
        Object.entries(teamsByWinningPercentage),
        ([winningPercentage]) => `${winningPercentage}`.padStart(4, '0')
    ),
    1
);


// Do some math or something? idk??
const graph = graphSequencer({
    graph: defeatedOpponentsByTeam,
    groups,
});


// `graphSequencer` gives us the teams back in reverse-standings order,
// so let's reverse them again!
const chunks = [...graph.chunks].reverse();


// This looks complicated, but I'm just bending over backwards
// to give tied teams the same ranking.
let rankings = [];

let rank = 1;
let chunk = chunks[0];
do {
    chunk.forEach(team => rankings.push(
        `${rank}. ${team}`
    ))
    rank = rank + chunk.length;

    const nextChunkIndex = chunks.indexOf(chunk) + 1;
    if (nextChunkIndex === 0) {
        break;
    }
    chunk = chunks[nextChunkIndex];
} while (rank < flatten(chunks).length);


console.log(rankings.join('\n'));