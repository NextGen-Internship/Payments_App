import React from 'react';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';


const OutlinedCard = ({user} : any) => {
    console.log(user);
  const card = (
    <React.Fragment>
      <CardContent>
      <Typography
          component="div"
          sx={{ fontSize: 14, textDecoration: ''}}
          color="text.secondary"
          gutterBottom
        >
          {`User ID: ${user.id}`}
        </Typography>
        <Typography variant="h5" component="div">
          {`${user.firstName} ${user.lastName}`}
        </Typography>
      </CardContent>
    </React.Fragment>
  );

  return (
    <Box sx={{
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '10vh',
        paddingX: '20%',
      }}>
      <Card variant="elevation">{card}</Card>
    </Box>
  );
};

export default OutlinedCard;
