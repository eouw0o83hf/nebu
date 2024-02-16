import Nav from './components/nav/Nav'

function App() {
  return (
    <div style={{verticalAlign: 'top'}}>
        <div style={{float: 'left', width: 200 }}>
          <Nav />
        </div>
        <div style={{float: 'left'}}>
          Welcome to nebu, take control of your own cloud storage!
        </div>
    </div>
  )
}

export default App
