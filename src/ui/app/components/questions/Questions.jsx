import React from 'react'
/*
    Landing page for questions
*/

import AskQuestions from './AskQuestion'

import { Link } from 'react-router-dom'
import { getQuestionsDummy } from '../../utils/apiCalls'

import './question.css'

class Questions extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            questions:[]
        }
    }
    async componentDidMount() {
        let questions = await getQuestionsDummy()
        if(questions.length > 0) {
            this.setState({questions})
        }
    }
    render() {
        const questions = this.state.questions
        return ( 
            <div id='tinQuestions'>
                {
                    this.state.questions.length > 0 &&
                    <div id='tinQuestionsList'>
                        <h3>Discover</h3>
                        {
                            questions.map(question => {
                                return (
                                    <Link to={`question/${question.Id}`} key={question.Id}>
                                        {question.Title}
                                    </Link>
                                )
                                
                            })
                        }
                    </div>
                }
                <div id='tinQuestionsHeader'>
                    <AskQuestions />
                </div>
            </div>
        )
    }
}

export default Questions