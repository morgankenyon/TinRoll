const path = require('path')
const HtmlWebPackPlugin = require('html-webpack-plugin')    

module.exports = {
    entry: './app/index.js',
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: 'index_bundle.js'
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