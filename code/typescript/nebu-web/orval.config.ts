import {defineConfig} from 'orval'

export default defineConfig({
    nebu: {
        input: {
            target: '../../contracts/api.json'
        },
        output: {
            clean: true,
            mode: 'tags-split',
            target: 'src/api/api.ts',
            schemas: 'src/api/model',
            client: 'react-query',
        }
    }
})
