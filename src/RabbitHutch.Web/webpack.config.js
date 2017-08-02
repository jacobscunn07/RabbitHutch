var path = require("path");
var webpack = require("webpack");

module.exports = {
    entry: {
    },
    target: 'web',
    output: {
        path: __dirname + "/content/build",
        filename: "[name].js",
        publicPath: "/content/build/"
    },
    devtool: "inline-source-map",
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            Tether: 'tether'
        })
    ],
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: [/node_modules/],

                use: [{
                    loader: 'babel-loader'
                }]
            },
            {
                test: /(\.css)$/,

                use: [
                    {
                        loader: 'style-loader'
                    },
                    {
                        loader: 'css-loader'
                    }
                ]
            },
            {
                test: /\.less$/,
                use: [
                    {
                        loader: 'style-loader'
                    },
                    {
                        loader: 'css-loader'
                    },
                    {
                        loader: 'less-loader'
                    }
                ]
            },
            {
                test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
                use: [{
                    loader: 'file-loader'
                }]
            },
            {
                test: /\.(woff|woff2)$/,
                use: [{
                    loader: 'url-loader?prefix=font/&limit=5000'
                }]
            },
            {
                test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
                use: [{
                    loader: 'url-loader?limit=10000&mimetype=application/octet-stream'
                }]
            },
            {
                test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
                use: [{
                    loader: 'url-loader?limit=10000&mimetype=image/svg+xml'
                }]
            },
            {
                test: /\.js$/,
                include: [/(react)/],
                exclude: [/(node_modules)/, /vendor/],

                use: {
                    loader: 'eslint-loader',
                    options: {
                        enforce: 'pre',
                        configFile: path.resolve(__dirname, "Content/react/.eslintrc")
                    }
                }
            }
        ]
    }
}
