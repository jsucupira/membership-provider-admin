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
            output: ["lib"]
        },
        typescript: {
            options: {
                module: "commonjs"
            },
            custom: {
                src: ['./scripts/app/*/*.ts'],
                dest: './lib/app'
            }
        },
        concat: {
            custom: {
                src: ['./lib/app/*/*.js'],
                dest: './scripts/app/combined.js'
            },
            vendor: {
                src: ['lib/angular/*.js', 'lib/angular-route/*.js'],
                dest: 'lib/angular/combined.js'
            }
        },
        bower: {
            install: {
                options: {
                    cleanTargetDir: false,
                    cleanBowerDir: false,
                    install: true,
                    copy: true,
                    layout: "byComponent"
                }
            }
        },
        less: {
            production: {
                options: {
                    cleancss: true,
                    compress: false,
                    relativeUrls: true
                },
                files: {
                    'lib/bootstrap/bootstrap.css': 'lib/temp/bootstrap/less/bootstrap.less'
                }
            }
        },
    });

    grunt.loadNpmTasks("grunt-contrib-less");
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-typescript");
    grunt.loadNpmTasks('grunt-bower-task');
    //grunt.loadNpmTasks('grunt-bower');

    grunt.registerTask("default", ["bower:install", "typescript", "less:production"]);
    grunt.loadNpmTasks("grunt-bower-task");
};