function() {    
  var env = karate.env; // get system property 'karate.env'
  karate.log('karate.env system property was:', env);
  if (!env) {
    env = 'dev';
  }
  var config = {
    env: env,
	baseUrl: 'https://bnym-horizon-dev.digiterre.cloud/api',
	contentType: 'application/json',
    authHeader: { username: 'credit', password: 'creditPassword' },
  }
  if (env == 'qa') {
    baseUrl: 'https://bnym-horizon-qa.digiterre.cloud/api'
  }
  return config;
}