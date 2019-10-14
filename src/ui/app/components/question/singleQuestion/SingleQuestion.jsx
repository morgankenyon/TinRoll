import React, { useState, useEffect } from 'react'
import '@babel/polyfill'

import './single.css'

const SingleQuestion = (props) => {
    const [question, setQuestion] = useState({});

    async function fetchQuestion() {
        let questionId = props.match.params.id;
        const res = await fetch(`http://localhost:1076/api/questions/${questionId}`); //TODO: extract to some environmental variable
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
                question.id <= 0 &&
                <h2>Loading...</h2>
            }
            {
                question.id > 0 &&
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