import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const PageNavigator = ({ pageId } : any) => {

  const navigate = useNavigate();

  useEffect(() => {
    if (pageId) {
      console.log(`Navigating to page with id: ${pageId}`);
      navigate(`/profile/${pageId}`);
    }
  }, [pageId, navigate]);

  return null;
};

export default PageNavigator;