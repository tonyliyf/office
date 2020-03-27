import path from 'path';
import prompt from 'prompt';
import fs from 'fs';

import { getInput, writeFile } from './utils';

const configFile = path.join(process.cwd(), 'cordova-hcp.json');
const loginFile = path.join(process.cwd(), '.chcplogin');

const schema = {
  properties: {
    key: {
      description: 'Amazon Access Key Id',
      message: 'You need to provide the Amazon Access Key Id',
      required: true,
    },
    secret: {
      description: 'Amazon Secret Access Key',
      message: 'You need to provide the Secret Access Key',
      required: true,
    },
  },
};

export function execute(context) {
  validateConfig();

  prompt.override = context.argv;
  prompt.message = 'Please provide';
  prompt.delimiter = ': ';
  prompt.start();

  getInput(prompt, schema)
    .then(content => writeFile(loginFile, content))
    .then(done);
}

function validateConfig() {
  let config;

  try {
    config = fs.readFileSync(configFile, 'utf8');
  } catch(e) {
    console.log('Cannot parse cordova-hcp.json. Did you run cordova-hcp init?');
    process.exit(0);
  }

  if (!config) {
    console.log('You need to run "cordova-hcp init" before you can run "cordova-hcp login".');
    console.log('Both commands needs to be invoked in the root of the project directory.');
    process.exit(0); // eslint-disable-line no-process-exit
  }
}

function done(err) {
  if (err) {
    return console.log(err);
  }

  console.log('Project initialized and .chcindex.plogin file created.');
  console.log('You SHOULD add .chcplogin to your .gitignore');
  console.log('( echo \'.chcplogin\' >> .gitignore )');
}
