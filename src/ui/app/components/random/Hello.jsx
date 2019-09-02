import React from 'react'

import { getDataObjectDummy } from '../../utils/apiCalls'

class Hello extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            message: 'Loading',
            question:{}
        }
    }

    async componentDidMount() {
        let id = 23423
        let response = await getDataObjectDummy(id)
        if(response !== undefined) {
            this.setState({message:'', question:response})
        } else {
            this.setState({message:'Cannot find question'})
        }
        
    }

    // async componentDidMount() {
    //     let endpoint = `localhost:5000/hello`
    //     let response = await getDataObject(endpoint)
    //     console.log(response)
    // }

    render() {
        let question = this.state.question
        return (
            <div id='tinHello'>
                {
                    this.state.message !== '' &&
                    <p>{this.state.message}</p>
                }

                {
                    this.state.question.Title &&
                    <ul>
                        <li>{question.Id}</li>
                        <li>{question.Title}</li>
                        <li>{question.Content}</li>
                    </ul>
                }

            </div>
        )
    }
}

export default Hello