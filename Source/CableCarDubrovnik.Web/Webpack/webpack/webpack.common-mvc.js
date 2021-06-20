const Path = require('path');
// const CleanWebpackPlugin = require('clean-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: {
        app: Path.resolve(__dirname, '../src/js/app.js'),
        cookies: Path.resolve(__dirname, '../src/js/cookie-consent.js'),
        contact: Path.resolve(__dirname, '../src/js/contact-us.js'),
        tour: Path.resolve(__dirname, '../src/js/tour.js'),
        bookingTimes: Path.resolve(__dirname, '../src/js/bookingTimes.js'),
        tourPayment: Path.resolve(__dirname, '../src/js/tourPayment.js'),
    },
    output: {
        path: Path.join(__dirname, '../../wwwroot'),
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
        new CopyWebpackPlugin([{ from: Path.resolve(__dirname, '../public'), to: './' }]),

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