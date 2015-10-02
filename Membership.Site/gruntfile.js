/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        clean: {
            options: {
                force: true
            },
            output: ["./scripts/app/_output", "./scripts/app/_vendor"]
        },
        typescript: {
            options: {
                module: "commonjs"
            },
            custom: {
                src: ['./scripts/app/*/*.ts'],
                dest: './scripts/_output'
            }
        },
        concat: {
            custom: {
                src: ['./scripts/_output/*/*.js'],
                dest: './scripts/_output/combined.js'
            },
            vendor: {
                src: ['./scripts/vendor/*/*.js'],
                dest: './scripts/_vendor/combined.js'
            }
        },


    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-typescript");

    grunt.registerTask("default", ["typescript"]);
};