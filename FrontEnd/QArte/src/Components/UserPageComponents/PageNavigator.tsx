import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const PageNavigator = ({ pageId, userId } : any) => {

  const navigate = useNavigate();

  useEffect(() => {
    if (pageId) {
       
      navigate(`/explore/${userId}/${pageId}`);
    }
  }, [pageId, navigate]);

  return null;
};

export default PageNavigator;