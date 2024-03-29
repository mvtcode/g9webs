﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Slider.ascx.cs" Inherits="Website.UserControl.Home.Slider" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<div id="wrapper">
    <div class="slider-wrapper theme-default">
        <div id="slider" class="nivoSlider">
            <%=sContent%>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(window).load(function() {
    $('#slider').nivoSlider({
        effect: 'random', // Specify sets like: 'fold,fade,sliceDown'
        slices: 15, // For slice animations
        boxCols: 8, // For box animations
        boxRows: 4, // For box animations
        animSpeed: 500, // Slide transition speed
        pauseTime: 8000, // How long each slide will show
        startSlide: 0, // Set starting Slide (0 index)
        directionNav: true, // Next & Prev navigation
        directionNavHide: true, // Only show on hover
        controlNav: false, // 1,2,3... navigation
        controlNavThumbs: false, // Use thumbnails for Control Nav
        pauseOnHover: true, // Stop animation while hovering
        manualAdvance: false, // Force manual transitions
        prevText: 'Prev', // Prev directionNav text
        nextText: 'Next', // Next directionNav text
        randomStart: true, // Start on a random slide
        beforeChange: function() { }, // Triggers before a slide transition
        afterChange: function() { }, // Triggers after a slide transition
        slideshowEnd: function() { }, // Triggers after all slides have been shown
        lastSlide: function() { }, // Triggers when last slide is shown
        afterLoad: function() { } // Triggers when slider has loaded
    });
    });
</script>
