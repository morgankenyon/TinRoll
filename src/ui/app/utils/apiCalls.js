const axios = require('axios')

const dummyQuestions = [
    {
        Id: 23423,
        Title: 'Javascript Help',
        Content: 'I can\'t get my javascript to work',
        CreatedDate: new Date()
    },
    {
        Id:51513,
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


const getDataObjectDummy = function(id) {
    const result = dummyQuestions.find(question => question.Id === id)
    return result
}

export { getDataObject, getDataObjectDummy }