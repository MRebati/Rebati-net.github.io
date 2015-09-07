(function(){
	'use strict';

	/*-----------------------------------------
	BACKGROUND PARALLAX INIT
	------------------------------------------*/
	if( $('.parallax').length ){
		$('body').imagesLoaded(function(){
			$(window).stellar({horizontalOffset:0,horizontalScrolling:!1});
		});
	};

	/*-----------------------------------------
	MAIN NAV INIT
	------------------------------------------*/
	function navTrigger(){
		var navTrigger = $('.main-nav-trigger').not('.mobile-nav-trigger'),
			mainNavContainer = $('.main-nav-container'),
			wrapper = $('.wrapper');

		navTrigger.on('click', function(event) {
			event.preventDefault();
			mainNavContainer.toggleClass('slide-in');
			$(this).toggleClass('slide-out');
		});

		wrapper.on('click', function(event) {
			mainNavContainer.removeClass('slide-in');
			navTrigger.removeClass('slide-out');
		});
	};
	navTrigger();

	/*-----------------------------------------
	MOBILE NAV INIT
	------------------------------------------*/
	function mobileNav(){
		var mobileNavContainer = $('.mobile-nav-container'),
			mainNavContainer = $('.main-nav-container'),
			navTrigger = $('.mobile-nav-trigger');

		mainNavContainer.find('.logo-container').clone().appendTo(mobileNavContainer);
		mainNavContainer.find('.main-nav').clone().appendTo(mobileNavContainer);

		navTrigger.on('click', function(event) {
			event.preventDefault();
			$(this).siblings('.main-nav').slideToggle();
		});
	};
	mobileNav();

	/*-----------------------------------------
	SCROLLTO INIT
	------------------------------------------*/
	$('.main-nav.onepage-nav').onePageNav();

	/*-----------------------------------------
	TEAM CAROUSEL
	------------------------------------------*/
	function teamCarousel(){

		var memberInfo = $(".members-details-container"),
			memberImage = $(".members-images-container");

		memberInfo.owlCarousel({
			items : 1,
			singleItem : true,
			loop: true,
			nav: true,
			mouseDrag: false,
			animateIn: 'fadeIn',
			animateOut: 'fadeOutRight',
			navContainer: '.team-carousel-nav',
			navText: ['<span></span>', '<span></span>']
		});
		memberImage.owlCarousel({
			items : 1,
			singleItem : true,
			mouseDrag: false,
			animateIn: 'fadeIn',
			animateOut: 'fadeOutRight',
			loop: true
		});

		memberInfo.on('change.owl.carousel', function(event) {
			memberImage.trigger('to.owl.carousel', event.item.index - 1);
		});

	};
	/*--- Team Carousel Init ---*/
	if ( $('.team').length ) {
		$('.team').imagesLoaded(function(){
			teamCarousel();
		});
	};

	/*-----------------------------------------
	TWEETER FEED
	------------------------------------------*/
	if( $('.tweets-container').length ) {
        $('.tweet').twittie({
            username: 'google',
            dateFormat: '%B %d, %Y',
            template: '<p>{{tweet}}<span>{{date}}</span></p>',
            count: 1,
            hideReplies: true,
            apiPath: 'php/twitter-feed/tweet.php'
        });
    };

	/*-----------------------------------------
	GALLERY INIT
	------------------------------------------*/
	if ( $('.gallery').length ) {
		$('.gallery-items-container').find('ul').mixItUp({
			animation: {
				duration: 550,
				effects: 'fade stagger(20ms) translateZ(-300px)',
				easing: 'cubic-bezier(0.645, 0.045, 0.355, 1)'
			}
		});
	};

	/*-----------------------------------------
	POPUP INIT
	------------------------------------------*/
	if ( $('.popup-trigger').length ) {
		$('.popup-trigger').magnificPopup({
			type: 'image',
		  	gallery: {
		    	enabled: true
		  	},
			removalDelay: 500,
			mainClass: 'mfp-fade'
		});
	};

	/*-----------------------------------------
	MENU CAROUSEL INIT
	------------------------------------------*/
	if ( $('.menus').length ) {
		var menuCarousel = $('.menu-carousel').owlCarousel({
			singleItem: true,
			items: 1,
			nav: true,
			mouseDrag: false,
			navSpeed: 1000,
			animateIn: 'fadeIn',
			animateOut: 'fadeOutDown',
			navContainer: '.menu-carousel-nav',
			navText: ['<span></span>', '<span></span>']
		});
	};

	function menuMeals(){
		
		var menuMeals = $('.menu-meals'),
			menuMealsThumbnail = menuMeals.owlCarousel({
			items: 1,
			singleItem: true,
			mouseDrag: false,
			touchDrag: false
		});

		menuMeals.find('.owl-item').on('click', function(event) {
			var $this = $(this);
			$this.addClass('active').siblings().removeClass('active');
			menuCarousel.trigger('to.owl.carousel', $this.index());
		});

		menuCarousel.on('changed.owl.carousel', function(event) {
			var activeMenu = event.item.index;
			console.log(activeMenu);
			menuMeals.find('.owl-item:nth-child('+ (activeMenu + 1) + ')' ).addClass('active').siblings().removeClass('active')
		});

	};
	if ( $('.menu-meals').length ) {
		menuMeals();
	};

	/*-----------------------------------------
	CONTACT FORM INIT
	------------------------------------------*/
	function contactForm() {

	    var form = $('#contact-form');
	    var formMessages = $('#form-messages');
        $(formMessages).slideUp();

	    $(form).submit(function(event) {
	        event.preventDefault();
	        var formData = $(form).serialize();

	        if ( !$('#name').val() || !$('#email').val() || !$('#message').val() ) {
	        	$('#form-messages').text('Please Complete All inputs');
	        } else {
	        	$('#form-messages').text('Sending your message. Please wait...').slideDown();
	        };

	        $(formMessages).removeClass('error').removeClass('success');

	        $.ajax({
	            type: 'POST',
	            url: $(form).attr('action'),
	            data: formData
	        })
	        .done(function(response) {
	            $(formMessages).removeClass('error').delay(2000).slideUp();
	            $(formMessages).addClass('success').delay(2000).slideUp();

	            $(formMessages).text(response);

	            $('#name').val('');
	            $('#email').val('');
	            $('#message').val('');
	        })
	        .fail(function(data) {
	            // Make sure that the formMessages div has the 'error' class.
	            $(formMessages).removeClass('success').delay(2000).slideUp();
	            $(formMessages).addClass('error').delay(2000).slideUp();

	            // Set the message text.
	            if (data.responseText !== '') {
	                $(formMessages).text(data.responseText);
	            } else {
	                $(formMessages).text('Oops! An error occured and your message could not be sent.');
	            }
	        });
	    });
	};
	contactForm();

	/*-----------------------------------------
	HEADER BANNER FADE EFFECT
	------------------------------------------*/
	function headerBanner(){
		var introSection = $('.top-banner-bg'),
			topBanner = $('.top-banner'),
			topImage = topBanner.find('.top-image'),
			bottomImage = topBanner.find('.bottom-image'),
			introSectionHeight = introSection.height(),
			scaleSpeed = 0.3,
			opacitySpeed = 1; 
		var MQ = 991;

		triggerAnimation();
		$(window).on('resize', function(){
			triggerAnimation();
		});
		function triggerAnimation(){
			if($(window).width()>= MQ) {
				$(window).on('scroll', function(){
					window.requestAnimationFrame(animateIntro);
				});
			} else {
				$(window).off('scroll');
			}
		}
		function animateIntro () {
			var scrollPercentage = ($(window).scrollTop()/introSectionHeight).toFixed(5),
				scaleValue = 1 - scrollPercentage*scaleSpeed;
			if( $(window).scrollTop() < introSectionHeight) {
				topBanner.css({
					'opacity': 1 - scrollPercentage * 1.6
				});
			}
		};
		topBanner.imagesLoaded(function(){
			topImage.addClass('animated fadeInDown')
			bottomImage.addClass('animated fadeInDown')
		});
	};
	/*--- Header Banner Fade Effect Init ---*/
	if ( $('.top-banner-container').length ) {
		headerBanner();
	};

	/*-----------------------------------------
	MEMBERS CAROUSEL
	------------------------------------------*/
	function membersCarousel(){
		var membersCarousel = $('.members-carousel');
		membersCarousel.find('ul').owlCarousel({
			items: 1,
			loop: true,
			center: true,
			responsive : {
			    496: {
			        items: 2
			    },
			    767: {
			        items: 3
			    },
			    992 : {
			        items: 4
			    },
			    1199 : {
			        items: 5
			    }
			}
		});
	};
	if ( $('.members-carousel').length ) {
		$('.members-carousel').imagesLoaded(function(){
			membersCarousel();
		});
	};

	/*-----------------------------------------
	TESTIMONIALS CAROUSEL
	------------------------------------------*/
	function testimonialsCarousel(){
		var testimonialsCarousel = $('.testimonial-carousel');
		testimonialsCarousel.owlCarousel({
			singleItem: true,
			items: 1,
			loop: true,
			dots: true,
			autoplay: true,
			autoplayTimeout: 3500,
			autoplayHoverPause: true,
			animateIn: 'fadeInLeft',
			animateOut: 'fadeOutRight',
			dotsContainer: '.testimonial-carousel-nav'
		});
	};
	if ( $('.testimonial-carousel').length ) {
		testimonialsCarousel();
	};

	/*-----------------------------------------
	CLIENTS CAROUSEL
	------------------------------------------*/
	function clientsCarousel(){
		var clientsCarousel = $('.clients-carousel');
		clientsCarousel.owlCarousel({
			items: 1,
			autoplay: true,
			autoplayTimeout: 3500,
			autoplayHoverPause: true,
			responsive : {
			    496: {
			        items: 2
			    },
			    767: {
			        items: 3
			    },
			    992 : {
			        items: 4
			    },
			    1199 : {
			        items: 5
			    }
			}
		});
	};
	if ( $('.clients-carousel').length ) {
		clientsCarousel();
	};

	/*-----------------------------------------
	BLOG POST CATEGORY FILTER INIT
	------------------------------------------*/
	if ( $('.blog-category-filter').length ) {
		$('.blog-post').mixItUp({
			animation: {
				duration: 550,
				effects: 'fade stagger(20ms) translateZ(-300px)',
				easing: 'cubic-bezier(0.645, 0.045, 0.355, 1)'
			}
		});
	};

	/*-----------------------------------------
	STORE CATEGORY FILTER INIT
	------------------------------------------*/
	if ( $('.store-category-filter').length ) {
		$('.store-items').mixItUp({
			animation: {
				duration: 550,
				effects: 'fade stagger(20ms) translateZ(-300px)',
				easing: 'cubic-bezier(0.645, 0.045, 0.355, 1)'
			}
		});
	};

	/*-----------------------------------------
	ITEM SLIDESHOW
	------------------------------------------*/
	function itemSlideshow(){

		var itemSlideshow = $(".item-slideshow"),
			mainImage = itemSlideshow.find('.main-image'),
			thumbnails = itemSlideshow.find('.thumbnails');

		mainImage.owlCarousel({
			items : 1,
			singleItem : true,
			animateIn: 'fadeInLeft',
			animateOut: 'fadeOutRight'
		});
		thumbnails.owlCarousel({
			items : 2,
			margin: 15,
			responsive : {
			    768: {
			        items: 3 
			    }
			}
		});

		thumbnails.find('.owl-item').on('click', function() {
			$(this).addClass('active').siblings().removeClass('active');
			mainImage.trigger('to.owl.carousel', $(this).index());
		});

	};
	/*--- Item Slideshow Init ---*/
	if ( $('.item-slideshow').length ) {
		$('.item-slideshow').imagesLoaded(function(){
			itemSlideshow();
		});
	};

	/*------------------------------------------
	MEDIAELEMENTS INIT
	------------------------------------------*/
	if ( $('video').length ) {
		var videoPlayer = new MediaElementPlayer('video');
	};
	if ( $('audio').length ) {
		var audioPlayer = $('audio').mediaelementplayer();
	};

	/*------------------------------------------
	PROMO VIDEO
	------------------------------------------*/
	if ( $('.promo-video').length ) {
		$('.promo-video').find('video').on('play', function(){
			$('.promo-video').find('.promo-contents').fadeOut('200');
		});
		$('.promo-video').find('video').on('pause', function(){
			$('.promo-video').find('.promo-contents').fadeIn('200');
		});
	};


	/*------------------------------------------
	SCROLL REVEAL INIT
	------------------------------------------*/
	if ( $('.wow').length ) {
		var wow = new WOW({mobile: false});
		wow.init();
	};


	/*------------------------------------------
	CART ITEM COUNT INIT
	------------------------------------------*/
	if ( $('.cart-item-count').length ) {
		$('.cart-item-count').stepper();
	};

	/*------------------------------------------
	MAIN NAV NICESCROLL INIT
	------------------------------------------*/
	function mainNavNicescroll(){
		if ( $('.main-nav-container').length ) {
			$('.main-nav-container').niceScroll({
		        cursoropacitymax: 0.3
			});
		};
	};
	mainNavNicescroll();

	/*------------------------------------------
	MOBILE NAV STICKY INIT
	------------------------------------------*/
	function mobileNavStickyInit(){
		var mobileNavContainer = $('.mobile-nav-container'),
			mobileNavHeight = mobileNavContainer.outerHeight(),
			$window = $(window),
			wrapper = $('.wrapper');

		$('.main-header .logo-container').imagesLoaded(function(){
			$window.on('scroll', function(){
				//The window.requestAnimationFrame() method tells the browser that you wish to perform an animation- the browser can optimize it so animations will be smoother
				window.requestAnimationFrame(mobileNav);
			});
		});

		function mobileNav(){

			if ( $window.scrollTop() > mobileNavHeight && $window.width() <= 991 ) {
				$('.mobile-nav-container').addClass('sticky animated fadeInDown');
				wrapper.css('padding-top', mobileNavHeight);
			} else {
				$('.mobile-nav-container').removeClass('sticky animated fadeInDown');
				wrapper.css('padding-top', 0);
			};
		};
	};
	mobileNavStickyInit();

    /*------------------------------------------------------------
    FUNCTIONS THAT NEED TO RUN WHEN WINDOW IS RESIZED
    -------------------------------------------------------------*/
    $(window).on('resize', function() {
    	mobileNavStickyInit();
    });


})();