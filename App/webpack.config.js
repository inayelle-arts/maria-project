const path = require('path');

const tsSourcesDir = path.resolve('./Static/scripts/ts');
const tsOutputDir = path.resolve('./Static/scripts/js');

module.exports = {
    mode: 'development',
    entry: `${tsSourcesDir}/main.ts`,
    resolve: {
        extensions: ['.webpack.js', '.web.js', '.ts', '.js']
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                exclude: /node_modules/,
                use: 'ts-loader'
            }
        ]
    },
    output: {
        filename: 'bundle.js',
        path: tsOutputDir
    },
    watchOptions: {
        aggregateTimeout: 300,
        poll: 1000,
        ignored: /node_modules/
    }
};