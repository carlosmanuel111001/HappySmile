import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  base: 'http://localhost:9000/',
  server: {
    port: 9000
  },
  preview: {
    port: 9000
  }
})
