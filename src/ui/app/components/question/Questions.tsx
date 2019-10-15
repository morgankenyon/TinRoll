// import React, { useState, useEffect } from 'react'

// // id	integer($int32)
// // title	string
// // content	string
// // userId	integer($int32)
// // createdDate	string($date-time)
// // updatedDate	string($date-time)

// class QuestionDto {
//     id: number;
//     title: string;
//     content: string;
//     userId: number;
//     createdDate: Date;
//     updatedDate: Date;
// }

// const Questions = () => {
//     const [questions, setQuestions] = useState<QuestionDto[] | null>();

//     async function fetchQuestion() {
//         const res = await fetch(`http://localhost:1076/api/questions/`); //TODO: extract to some environmental variable
//         res
//             .json()
//             .then(res => setQuestions(res))

//         fetch(`http://swapi.co/api/people/1/`)
//             .then(res => res.json<QuestionDto>())
//             .then(res => setQuestions(res));
//     }
// };
// export default Questions;