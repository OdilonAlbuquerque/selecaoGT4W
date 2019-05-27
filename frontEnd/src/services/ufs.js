import { httpIBGE } from './config'

export default {

    listar:() => {
        return httpIBGE.get('estados')
    }
}