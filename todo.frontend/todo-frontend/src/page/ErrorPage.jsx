import {useRouteError} from 'react-router-dom'

export default function ErrorPage () {

    const error = useRouteError();
    console.log(error);

    return (
        <div id="error-page" style={{textAlign:'center',marginTop: "50px"}}>
            <h1>Oops!</h1>
            <p>Sorry, some error has happened</p>
            <p><i>{error.statusText || error.message}</i></p>
        </div>
        )

}