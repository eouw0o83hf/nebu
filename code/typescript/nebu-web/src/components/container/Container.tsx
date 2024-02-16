import logo from '/src/assets/nebu.svg'
import { NavLink } from 'react-router-dom'

const LiveLink = ({to, title}: {to: string, title: string}) => {
    return (
    <li style={{ marginBottom: 5 }}>
        <NavLink to={to} style={({ isActive }: {isActive: boolean }) =>
            isActive
            ? { color: 'black', textDecoration: 'none'}
            : { color: 'blue' }
        }>{title}</NavLink>
    </li>)
}

type Props = {
    children: React.ReactNode
}

const Container = (props: Props) => {
    return (
        <div style={{verticalAlign: 'top'}}>
            <div style={{float: 'left', width: 200, marginTop: 10, marginLeft: 10 }}>
                <div style={{ display: 'inline-block'}}>
                    <img src={logo} alt="nebu" width={50} />
                    <span style={{ marginLeft: 10 }}>nebu</span>
                </div>
                <ul style={{ paddingLeft: 5, listStyle: 'none' }}>
                    <LiveLink to="/" title="Home" />
                    <LiveLink to="/buckets" title="Buckets" />
                    <LiveLink to="/files" title="Files" />
                </ul>
            </div>
            <div style={{float: 'left', marginTop: 10}}>
                {props.children}
            </div>
        </div>
    )
}

export default Container;
