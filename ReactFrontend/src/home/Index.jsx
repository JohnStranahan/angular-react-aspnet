import React, {useState, Text} from 'react'
import { makeStyles } from '@material-ui/core/styles'
import { Button, TextField } from '@material-ui/core'
import config from 'config';
import axios from 'axios'
const baseUrl = `${config.apiUrl}`;
import 'regenerator-runtime/runtime'
import { fetchWrapper} from '@/_helpers';

const useStyles = makeStyles(theme => ({
  alignItemsAndJustifyContent: {
    width: 500,
    height: 80,
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    marginLeft: '25%'
  },
}))



const Home = () => {
  const classes = useStyles()

  const [count, setCount] = useState(0);

  const [result, setResult] = useState(null);

  async function handleSubmit() {
    console.log('You clicked submit.');
    console.log(count)
    console.log(baseUrl)
    const data = await fetchWrapper.postUrl(`${baseUrl}/matlab/run-script-url-input/` + count, {});
    setResult(data.result)
    };

  const handleChange = (e) => {
    setCount(e.target.value);
  };

  return (
    <React.Fragment>
      <div className={classes.alignItemsAndJustifyContent}>
      <label>Convert Fahrenheit to Celcius using Matlab DLL</label>
      </div>
      <div className={classes.alignItemsAndJustifyContent}>
      <TextField value={count} onChange={handleChange} type="number" id="standard-basic" label="Fahrenheit" defaultValue="0"   />
      </div>
      <div className={classes.alignItemsAndJustifyContent}>
      <Button onClick={handleSubmit} variant="contained" color="primary">
             Calculate
       </Button>

      </div>
      <div className={classes.alignItemsAndJustifyContent}>
      <p>Answer: </p>
      <p>{result !== null ? " " + result : null}</p>
      </div>
     

    </React.Fragment>
  )
}


export { Home };