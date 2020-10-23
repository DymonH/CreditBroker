var gulp = require('gulp');
var inject = require('gulp-inject');
var series = require('stream-series');
var bom = require('gulp-bom');

gulp.task('inject', function () {
    var target = gulp.src('../Happylend.CreditBroker.ARM/views/home/index.cshtml');
    // It's not necessary to read the files (will speed up things), we're only after their paths:
    var polyfillStream_es2015 = gulp.src(['../Happylend.CreditBroker.ARM/front/polyfills-es2015*.js'], {read: false});
    var vendorStream_es2015 = gulp.src(['../Happylend.CreditBroker.ARM/front/vendor-es2015*.js'], {read: false});
    var runtimeStream_es2015 = gulp.src(['../Happylend.CreditBroker.ARM/front/runtime-es2015*.js'], {read: false});
    var mainStream_es2015 = gulp.src(['../Happylend.CreditBroker.ARM/front/main-es2015*.js'], {read: false});
    var polyfillStream_es5 = gulp.src(['../Happylend.CreditBroker.ARM/front/polyfills-es5*.js'], {read: false});
    var vendorStream_es5 = gulp.src(['../Happylend.CreditBroker.ARM/front/vendor-es5*.js'], {read: false});
    var runtimeStream_es5 = gulp.src(['../Happylend.CreditBroker.ARM/front/runtime-es5*.js'], {read: false});
    var mainStream_es5 = gulp.src(['../Happylend.CreditBroker.ARM/front/main-es5*.js'], {read: false});

    return target.pipe(inject(series(
        polyfillStream_es2015,
        vendorStream_es2015,
        runtimeStream_es2015,
        mainStream_es2015,
        polyfillStream_es5,
        vendorStream_es5,
        runtimeStream_es5,
        mainStream_es5
    ), {
        transform: function (filename) {
            var index = filename.lastIndexOf("/");
            if (index != -1)
                filename = filename.substring(index + 1);

            if (filename.indexOf("-es2015.") != -1)
                return '<script src="@Url.Content("~/front/' + filename + '")" type="module"></script>';
            else if (filename.indexOf("-es5.") != -1)
                return '<script src="@Url.Content("~/front/' + filename + '")" nomodule></script>';
            else
                return '<script src="@Url.Content("~/front/' + filename + '")" type="text\javascript"></script>';
        }
    }))
        .pipe(bom())
        .pipe(gulp.dest('../Happylend.CreditBroker.ARM/views/home'));
});

gulp.task('inject-client', function () {
    var target = gulp.src('../Happylend.NewClient/views/home/index.cshtml');
    // It's not necessary to read the files (will speed up things), we're only after their paths:
    var polyfillStream_es2015 = gulp.src(['../Happylend.NewClient/front/polyfills-es2015*.js'], {read: false});
    var vendorStream_es2015 = gulp.src(['../Happylend.NewClient/front/vendor-es2015*.js'], {read: false});
    var runtimeStream_es2015 = gulp.src(['../Happylend.NewClient/front/runtime-es2015*.js'], {read: false});
    var mainStream_es2015 = gulp.src(['../Happylend.NewClient/front/main-es2015*.js'], {read: false});
    var polyfillStream_es5 = gulp.src(['../Happylend.NewClient/front/polyfills-es5*.js'], {read: false});
    var vendorStream_es5 = gulp.src(['../Happylend.NewClient/front/vendor-es5*.js'], {read: false});
    var runtimeStream_es5 = gulp.src(['../Happylend.NewClient/front/runtime-es5*.js'], {read: false});
    var mainStream_es5 = gulp.src(['../Happylend.NewClient/front/main-es5*.js'], {read: false});

    return target
    .pipe(inject(series(
			polyfillStream_es2015,
			vendorStream_es2015,
			runtimeStream_es2015,
			mainStream_es2015,
			polyfillStream_es5,
			vendorStream_es5,
			runtimeStream_es5,
			mainStream_es5
    ), {
        transform: function (filename) {
            var index = filename.lastIndexOf("/");
            if (index != -1)
                filename = filename.substring(index + 1);

            if (filename.indexOf("-es2015.") != -1)
                return '<script src="@Url.Content("~/front/' + filename + '")" type="module"></script>';
            else if (filename.indexOf("-es5.") != -1)
                return '<script src="@Url.Content("~/front/' + filename + '")" nomodule></script>';
            else
                return '<script src="@Url.Content("~/front/' + filename + '")" type="text\javascript"></script>';
        }
    }))
        .pipe(bom())
        .pipe(gulp.dest('../Happylend.NewClient/views/home'));
});
