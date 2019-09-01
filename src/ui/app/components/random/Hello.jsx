import React from 'react'

import { getDataObject } from '../../utils/apiCalls'

class Hello extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            message: 'Loading'
        }
    }

    async componentDidMount() {
        let endpoint = `localhost:5000/hello`
        let response = await getDataObject(endpoint)
        console.log(response)
    }

    render() {
        return (
            <div id='tinHello'>
                <p>{this.state.message}</p>
            </div>
        )
    }
}

export default Hello