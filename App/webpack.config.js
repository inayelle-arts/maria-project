const path = require('path');

const tsSourcesDir = path.resolve('./Static/scripts/ts');
const tsOutputDir = path.resolve('./Static/scripts/js');

module.exports = {
    mode: 'development',
    entry: {
        'main': `${tsSourcesDir}/main.ts`,
        'board': `${tsSourcesDir}/board.ts`
    },
    resolve: {
        extensions: ['.webpack.js', '.web.js', '.ts', '.js']
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                include: [`${tsSourcesDir}`],
                exclude: /node_modules/,
                use: {
                    loader: 'ts-loader',
                    options: {
                        instance: 'main',
                        configFile: `${tsSourcesDir}/tsconfig.json`
                    }
                }
            },
            {
                test: /\.ts$/,
                include: [`${tsSourcesDir}/board`],
                exclude: /node_modules/,
                use: {
                    loader: 'ts-loader',
                    options: {
                        instance: 'board',
                        configFile: `${tsSourcesDir}/tsconfig.json`
                    }
                }
            }
        ]
    },
    output: {
        path: tsOutputDir
    },
    watchOptions: {
        aggregateTimeout: 300,
        poll: 1000,
        ignored: /node_modules/
    }
};