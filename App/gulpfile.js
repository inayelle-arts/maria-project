'use strict';

const gulp = require("gulp");
const sass = require("gulp-sass");
const remove = require('gulp-clean');

const staticRoot = './Static';

const librariesRoot = './node_modules';

const srcScripts = `${staticRoot}/scripts/ts`;
const srcStyles = `${staticRoot}/styles/scss`;

const destScripts = `${staticRoot}/scripts/js`;
const destStyles = `${staticRoot}/styles/css`;

gulp.task('sass', function () {
    return gulp.src(`${srcStyles}/**/*.scss`)
               .pipe(sass().on('error', sass.logError))
               .pipe(gulp.dest(destStyles));
});

gulp.task('sass-watch', function () {
    return gulp.watch('./static/styles/scss/*.scss', 'sass');
});

gulp.task('prepare-bootstrap', function () {
    gulp.src(`${librariesRoot}/bootstrap/dist/js/bootstrap.js`)
        .pipe(gulp.dest(`${destScripts}/bootstrap`));


    return gulp.src(`${librariesRoot}/bootstrap/dist/css/bootstrap.css`)
               .pipe(gulp.dest(`${destStyles}/bootstrap`));
});

gulp.task('prepare-jquery', function () {
    gulp.src(`${librariesRoot}/jquery/dist/jquery.js`)
        .pipe(gulp.dest(`${destScripts}/jquery`));

    return gulp.src(
        `${librariesRoot}/jquery-validation/dist/jquery.validate.js`)
               .pipe(gulp.dest(`${destScripts}/jquery`));
});

gulp.task('prepare-fa', function () {
    const fontAwesomeRoot = `${librariesRoot}/@fortawesome/fontawesome-free`;
    const fontAwesomeDest = `${destStyles}/fontawesome`;

    gulp.src(
        `${fontAwesomeRoot}/css/all.css`)
        .pipe(gulp.dest(fontAwesomeDest));

    return gulp.src(`${fontAwesomeRoot}/webfonts/*`)
               .pipe(gulp.dest(`${destStyles}/webfonts`));
});

gulp.task('clean', function () {
    gulp.src(`${destScripts}/**/*`, {read: false, allowEmpty: true})
        .pipe(remove());

    return gulp.src(`${destStyles}/**/*`, {read: false})
               .pipe(remove());
});

gulp.task(
    'build',
    gulp.series(
        'prepare-fa',
        'prepare-bootstrap',
        'prepare-jquery',
        'sass'
    )
);

gulp.task('default', gulp.series('clean', 'build'));