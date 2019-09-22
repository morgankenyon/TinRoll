import React from 'react'

export default class Landing extends React.Component {
    constructor(props) {
        super(props)

    }

    componentDidMount() {
        console.log('mount landing')
    }

    componentDidUpdate() {
        console.log('update landing')
    }

    componentWillUnmount() {
        console.log('unmount landing')
    }
    render() {
        return (
            <div className='tin-landing'>
                <h1>Landing</h1>
            </div>
        )
    }
}