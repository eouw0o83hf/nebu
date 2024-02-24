import { useRouteError } from "react-router-dom";
import Container from "../container/Container";

const ErrorPage = () => {
    const error = useRouteError()
    
    return (<Container>  
        <h1>Error</h1>
        <pre>{JSON.stringify(error)}</pre>
    </Container>)
}

export default ErrorPage;
