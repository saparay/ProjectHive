import './css/loader.css'

export default function Loader(){
    return(
        <>
            <div className="custome-loader"></div>
            <div style={{textAlign: 'center', fontWeight: 'bold', margin: '6px'}}>Please Wait....</div>
        </>
    )
}