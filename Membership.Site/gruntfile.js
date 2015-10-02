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
            output: ["./scripts/app/_output"]
        },
        typescript: {
            options: {
                module: "commonjs"
            },
            all: {
                src: ['./scripts/app/*/*.ts'],
                dest: './scripts/app/_output'
            }
        },
        concat: {
            all: {
                src: ['./scripts/app/_output/*/*.js'],
                dest: './scripts/app/_output/combined.js'
            }
        },


    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-typescript");

    grunt.registerTask("default", ["typescript"]);
};