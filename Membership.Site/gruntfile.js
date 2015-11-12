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
                src: ['scripts/app/*/*.ts'],
                dest: 'lib/app'
            }
        },
        concat: {
            custom: {
                src: ['lib/app/*/*.js', 'scripts/app/app.js', 'scripts/app/roleRoute.js', 'scripts/app/userRoute.js'],
                dest: 'lib/output/app.js'
            },
            angular: {
                src: ['lib/angular/*.js', 'lib/angular-route/*.js'],
                dest: 'lib/output/angular.js'
            },
            toastr: {
                src: ['lib/toastr/toastr.js'],
                dest: 'lib/output/toastr.js'
            },
            jquery: {
                src: ['lib/jquery/jquery.js'],
                dest: 'lib/output/jquery.js'
            },
            bootstrap: {
                src: ['lib/bootstrap/bootstrap.js'],
                dest: 'lib/output/bootstrap.js'
            },
            combinejs: {
                src: ['lib/output/jquery.js', 'lib/output/angular.js', 'lib/output/bootstrap.js', 'lib/output/toastr.js', 'lib/output/app.js'],
                dest: 'lib/output/combined.js'
            },
            combinecss: {
                src: ['lib/output/bootstrap.css', 'lib/output/toastr.css'],
                dest: 'lib/output/combined.css'
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
            development: {
                options: {
                    cleancss: false,
                    compress: false,
                    relativeUrls: true
                },
                files: {
                    'lib/output/bootstrap.css': 'lib/temp/bootstrap/less/bootstrap.less',
                    'lib/output/toastr.css': 'lib/temp/toastr/toastr.less'
                }
            },
            production: {
                options: {
                    cleancss: true,
                    compress: true,
                    relativeUrls: true
                },
                files: {
                    'lib/output/bootstrap.css': 'lib/temp/bootstrap/less/bootstrap.less',
                    'lib/output/toastr.css': 'lib/temp/toastr/toastr.less'
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-less");
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks("grunt-typescript");
    grunt.loadNpmTasks('grunt-bower-task');
    //grunt.loadNpmTasks('grunt-bower');
    grunt.loadNpmTasks("grunt-bower-task");
    grunt.registerTask("default", ["bower:install", "less:development", "typescript", "concat"]);
};