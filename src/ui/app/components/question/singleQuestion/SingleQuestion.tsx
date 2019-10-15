import React, { useState, useEffect } from 'react'
import '@babel/polyfill'

import './single.css'

class QuestionDto {
    id?: number;
    title?: string;
    content?: string;
    userId?: number;
    createdDate?: Date;
    updatedDate?: Date;
}

const SingleQuestion = () => {
    const [question, setQuestion] = useState<QuestionDto | null>();

    async function fetchQuestion() {
        //let questionId = props.match.params.id;
        const res = await fetch(`http://localhost:1076/api/questions/1`); //TODO: extract to some environmental variable
        res
            .json()
            .then(res => setQuestion(res))
    }

    useEffect(() => {
        fetchQuestion();
        //TODO: need some cleanup function
    });

    return (
        <div className='t-single-question'>
            {
                question == null &&
                <h2>Loading...</h2>
            }
            {
                question != null &&
                <div className='t-s-q-question'>
                    <h2>{question.title}</h2>
                    <p>{question.createdDate}</p>
                    <p id='t-single-p'>{question.content}</p>
                </div>
            }
        </div>
    )
};
export default SingleQuestion;