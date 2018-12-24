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

function compileSass()
{
    return gulp.src(`${srcStyles}/*.scss`)
               .pipe(sass().on('error', sass.logError))
               .pipe(gulp.dest(destStyles));
}

function watchSass()
{
    return gulp.watch(`${srcStyles}/*.scss`, gulp.series(compileSass));
}

function prepareMaterialKit()
{
    gulp.src(`${librariesRoot}/material-kit/assets/js/material-kit.js`)
        .pipe(gulp.dest(`${destScripts}/material-kit`));


    return gulp.src(
        `${librariesRoot}/material-kit/assets/scss/**/*`)
               .pipe(gulp.dest(`${srcStyles}/material-kit`));
}

function prepareTypedJson()
{
    return gulp.src(`${librariesRoot}/typedjson/js/typedjson.js`)
               .pipe(gulp.dest(`${destScripts}`));
}

function prepareJquery()
{
    gulp.src(`${librariesRoot}/jquery/dist/jquery.js`)
        .pipe(gulp.dest(`${destScripts}/jquery`));

    return gulp.src(
        `${librariesRoot}/jquery-validation/dist/jquery.validate.js`)
               .pipe(gulp.dest(`${destScripts}/jquery`));
}

function prepareFontAwesome()
{
    const fontAwesomeRoot = `${librariesRoot}/@fortawesome/fontawesome-free`;
    const fontAwesomeDest = `${destStyles}/fontawesome`;

    gulp.src(
        `${fontAwesomeRoot}/css/all.css`)
        .pipe(gulp.dest(fontAwesomeDest));

    return gulp.src(`${fontAwesomeRoot}/webfonts/*`)
               .pipe(gulp.dest(`${destStyles}/webfonts`));
}

function clean()
{
    gulp.src(`${destScripts}/**/`, {read: false, allowEmpty: true})
        .pipe(remove());

    gulp.src(`${srcStyles}/material-kit/`, {read: false, allowEmpty: true})
        .pipe(remove());

    return gulp.src(`${destStyles}/**/`, {read: false})
               .pipe(remove());
}

gulp.task('sass', gulp.series(compileSass));

gulp.task('sass-watch', gulp.series(watchSass));

gulp.task('prepare-material-kit', gulp.series(prepareMaterialKit));

gulp.task('prepare-jquery', gulp.series(prepareJquery));

gulp.task('prepare-fa', gulp.series(prepareFontAwesome));

gulp.task('prepare-typedjson', gulp.series(prepareTypedJson));

gulp.task('clean', gulp.series(clean));

gulp.task(
    'build',
    gulp.series(
        'prepare-fa',
        'prepare-material-kit',
        'prepare-jquery',
        'prepare-typedjson',
        'sass'
    )
);

gulp.task('default', gulp.series('clean', 'build'));