import logo from '/src/assets/nebu.svg'

const Nav = () => {
    return (
    <>
        <img src={logo} alt="nebu" width={100} />
        <ul>
            <li>Home</li>
            <li>Files</li>
            <li>Settings</li>
        </ul>
    </>)
}

export default Nav
