const axios = require('axios')
const uuidv4 = require('uuid/v4')

const dummyQuestions = [
    {
        Id: uuidv4(),
        Title: 'Javascript Help',
        Content: 'I can\'t get my javascript to work',
        CreatedDate: new Date()
    },
    {
        Id:uuidv4(),
        Title: 'CSS Help',
        Content: 'My CSS skills are garbage',
        CreatedDate: new Date()
    }
]

const getDataObject = function(endpoint) {
    return axios.get(endpoint)
        .then(response => {
            console.log(response)
            return response
        })
}


const getQuestionDummy = function(id) {
    const result = dummyQuestions.find(question => question.Id === id)
    return result
}

const getQuestionsDummy = function() {
    return dummyQuestions
}

const postDummyQuestion = function(question) {
    dummyQuestions.push(question)
    console.log(dummyQuestions)
}

export { getDataObject, getQuestionDummy, getQuestionsDummy, postDummyQuestion }