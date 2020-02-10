const express = require('express')
const request = require('request')
var fs = require('fs');

const app = express()

let subscriptionKey = 'YOUR SUBSCRIPTION KEY'
let host = 'api.cognitive.microsoft.com';

// API Path
let path = 'https://bingsearchresourcesparkdev.cognitiveservices.azure.com/bing/v7.0/news/search';

// Search term
let search_term = 'Police Brutality North Miami Beach';

app.get('/', (req, res) => {
    res.send('<h1>Home Page</h1>')
})

app.get('/news', (req, res) => {
    const options = {
        method : 'GET',
        hostname : host,
        url : path + '?q=' + encodeURIComponent(search_term),
        headers : {
            'Ocp-Apim-Subscription-Key' : subscriptionKey,
        },
        qs: {            
            category: 'US_South'
        },
        json: true
    }

    request(options, function(error, response, body){
        if(error){
            throw new Error(error)
        }else{ 

            body = JSON.stringify(body, null, '  ')
            fs.writeFile("MY_API_RESULTS.json", body, function(err) {
                if (err) {
                    console.log('Error with writing JSON file');
                }
            });   
            res.send('Results were Found😁')
        }
    })    
})

// The port for your server
const PORT = process.env.PORT || 3000

app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`)
})