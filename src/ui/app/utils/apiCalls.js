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

export { getArrayData, getObjectData }