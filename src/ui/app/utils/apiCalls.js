import axios from 'axios'

const getArrayData = function(endpoint) {
    return axios.get(endpoint)
        .then(response => {
            return response.data
        })
}

const getObjectData = function(endpoint) {
    return axios.get(endpoint)
        .then(response => {
            return response
        })
}

const postObjectData = function(endpoint, data) {
    return fetch(endpoint, {
        method: 'post',
        headers: {
            'Content-Type':'application/json'
        },
        body:JSON.stringify(data)
    })
        .then(response => {
            return response
        })
}

export { getArrayData, getObjectData, postObjectData }