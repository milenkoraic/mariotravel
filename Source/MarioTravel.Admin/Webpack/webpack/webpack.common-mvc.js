const Path = require('path');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: {
        app: Path.resolve(__dirname, '../src/js/app.js'),
        custom: Path.resolve(__dirname, '../src/js/custom.js'),
    },
    output: {
        path: Path.join(__dirname, '../../wwwroot/'),
        filename: 'js/[name]/[name].js',
    },
    optimization: {
        splitChunks: {
            chunks: 'all',
            name(module, chunks, cacheGroupKey) {
                return cacheGroupKey;
            },
        },
    },
    plugins: [
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public/assets/img/'), to: './img' }]),
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public/fonts/'), to: './fonts' }]),
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public/lib/'), to: './lib' }]),
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public/vendor/'), to: './vendor' }]),
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public/favicon.ico'), to: './' }]),
    ],
    resolve: {
        alias: {
            '~': Path.resolve(__dirname, '../src'),
        },
    },
    module: {
        rules: [
            {
                test: /\.mjs$/,
                include: /node_modules/,
                type: 'javascript/auto',
            },
            {
                test: /\.(ico|jpg|jpeg|png|gif|eot|otf|webp|svg|ttf|woff|woff2)(\?.*)?$/,
                use: {
                    loader: 'file-loader',
                    options: {
                        name: '/assets/[name].[ext]',
                    },
                },
            },
        ],
    },
};