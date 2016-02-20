/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var debug = require('gulp-debug'); //logging
var del = require('del');
var runSequence = require('run-sequence');

var deployFolder = '../PVP.WebApi/wwwroot';

gulp.task('build', function (done) {
    runSequence('cleanServer',
                'copyClientToServer',
             function () {
                 console.log('.. all done ..');
                 done();
             });
});

gulp.task('cleanServer', function () {

    return del([
        '../PVP.WebApi/wwwroot/app',
        '../PVP.WebApi/wwwroot/scripts',
        '../PVP.WebApi/wwwroot/index.html'

    ], { force: true });;
    //return gulp.src(
    //  [
         
    //  ], { read: false }) // much faster
    //      .pipe(debug({ title: 'deleteing:' }))
    //      .pipe(rimraf({ force: true }));

});

gulp.task('copyClientToServer', function () {
    return gulp
       .src([
           'app/**/*',  
           'scripts/**/*',
           'index.html'
       ], { base: '.' })
        .pipe(debug({ title: 'copying:' }))
		.pipe(gulp.dest(deployFolder));
});