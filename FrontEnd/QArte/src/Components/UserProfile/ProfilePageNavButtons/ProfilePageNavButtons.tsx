import * as React from 'react';
import Button from '@mui/material/Button';

const ProfilePageNavButtons = ({ index, onShow, page }: any) => {
    return (
      <div
        style={{
          cursor: 'pointer',
          backgroundColor: 'transparent',
          padding: '8px', 
          margin: '4px',
        }}
        onClick={() => onShow(index)}
      >
        {page.pageName}
      </div>
    );
  };
  
  export default ProfilePageNavButtons;