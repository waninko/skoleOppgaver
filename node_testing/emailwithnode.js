var nodemailer = require('nodemailer');

var transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'linn.tester.node@gmail.com',
    pass: 'wtyr851987'
  }
});

var mailOptions = {
  from: 'linn.tester.node@gmail.com',
  to: 'josefine.magnussen@hg-gruppen.no',
  subject: 'Prøver å sende mail med Node',
  text: 'Schpanande om det funker!'
};

transporter.sendMail(mailOptions, function(error, info){
  if (error) {
    console.log(error);
  } else {
    console.log('Email sent: ' + info.response);
  }
});