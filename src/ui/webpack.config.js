const path = require('path')
const HtmlWebPackPlugin = require('html-webpack-plugin') 

module.exports = {
    entry: ['babel-polyfill', './app/index.js'],
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'index_bundle.js',
        publicPath: '/'
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/, 
                use: 'babel-loader' 
            },
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    'css-loader'
                ]
            }
        ]
    },
    devServer: {
        historyApiFallback: true
    },
    mode: 'development',
    plugins: [
        new HtmlWebPackPlugin({
            template: 'app/index.html'
        })
    ],
    resolve: {
        extensions: ['.js', '.jsx']
    }
}