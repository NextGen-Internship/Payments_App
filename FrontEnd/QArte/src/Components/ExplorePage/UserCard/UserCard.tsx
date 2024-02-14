import React from 'react';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import CardMedia from '@mui/material/CardMedia';

const OutlinedCard = ({user} : any) => {
    console.log(user);
  const card = (
    <React.Fragment>
    <CardContent style={{ display: 'flex', alignItems: 'center' }}>
      <CardMedia
        component="img"
        sx={{ height: '15%', marginRight: '20px', width: '8%'}}
        image={user.pictureURL}
        title="userPicture"
      />
      <div>
      <Typography variant="h4" component="div">
          {user.username}
        </Typography>
        <Typography
          component="div"
          sx={{ fontSize: 14, textDecoration: '' }}
          color="text.secondary"
          gutterBottom
        >
          {`${user.firstName} ${user.lastName}`}
        </Typography>

      </div>
    </CardContent>
  </React.Fragment>
  );

  return (
      <Card variant="elevation"
      style={{
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '5vh',
        marginTop: '2%',
        marginLeft: '20%',
        marginRight: '20%' }}>
        {card}
      </Card>
  );
};

export default OutlinedCard;
