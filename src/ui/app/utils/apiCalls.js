const axios = require('axios')

const getDataObject = function(endpoint) {
    return axios.get(endpoint)
        .then(response => {
            console.log(response)
            return response
        })
}

export { getDataObject }