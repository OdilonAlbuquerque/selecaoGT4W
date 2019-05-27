import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://gtapiweb.azurewebsites.net/api'
})

export const httpIBGE = axios.create({
    baseURL: 'https://servicodados.ibge.gov.br/api/v1/localidades'
})