var url = 'http://mylogger.io/log';

function log(message) {
    // send http RQ
    console.log(message);
}

module.exports.log = log;