module.exports = function(grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        webdriver: {
            tests: {
                configFile: './test/config/suite.wdio.conf.js'
            }
        }
    });

    grunt.loadNpmTasks('grunt-jasmine');
    grunt.loadNpmTasks('grunt-webdriver');
    grunt.registerTask('default', ['webdriver:tests']);
    //grunt.registerTask('default', ['webdriver:tests-mobile']);
};