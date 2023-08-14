import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {

  return (
    <div className='bg-blue-100'>
      <header className='h-48'>
        This should be the header
      </header>
      <div className='h-48'>
        <input type='text' 
              placeholder='Enter search text'
              className='p-10 rounded-lg'></input>
        <button className='mx-5 bg-red-400 hover:bg-violet-600'>Search</button>
      </div>
    </div>
  )
}

export default App
