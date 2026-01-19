# Confero Eco-Driving System

Vehicle telematics system for monitoring driving behavior and promoting eco-friendly driving habits.

## Overview

Final year project (FYP) featuring comprehensive vehicle monitoring with GPS tracking, performance calculations, weather integration, SMS alerts, and web-based visualization. Multi-component system combining desktop application, web interface, and background services.

## Features

- Real-time GPS tracking and trip recording
- Vehicle performance calculations
- Eco-driving score and feedback
- Weather integration
- SMS alert system
- Traffic information
- Web-based route visualization
- Database synchronization

## Components

### Main Application (Confero)
WPF desktop application with custom controls for vehicle monitoring and trip management.

### CWeatherWatch
Weather information integration service.

### SMSGateway / SMSGatewayHBM
SMS alert and notification system (two variants).

### SMSAlertReader
Service for reading and processing SMS alerts.

### TrafficWatch
Traffic information monitoring component.

### WebBrowser
Web-based route and map visualization.

### Configuration
System configuration management.

## Technology Stack

**Desktop:** C#, WPF, XAML  
**Hardware:** Phidgets sensors, GPS receiver  
**Backend:** Web services, SQL database  
**Communication:** SMS gateway integration

## Architecture

```
Desktop App (WPF)
├── GPS Module
├── Sensor Integration (Phidgets)
├── Performance Calculator
└── Database Sync

Background Services
├── Weather Watch
├── Traffic Watch
├── SMS Gateway
└── SMS Alert Reader

Web Interface
└── Map Visualization
```

## Installation

1. Clone repository
```bash
git clone https://github.com/tanchunsiong/confero-eco-driving.git
```

2. Open main solution in Visual Studio

3. Build all projects

4. Configure database connection strings

5. Install Phidgets drivers

6. Run main Confero application

## Hardware Requirements

- GPS receiver
- Phidgets sensor interface kit
- Compatible sensors (speed, fuel, etc.)

## Usage

1. Launch Confero desktop application
2. Connect GPS and sensors
3. Start trip recording
4. View real-time performance metrics
5. Review trip history and eco-driving scores

## License

MIT License

## Links

- Blog post: [Confero: Building a Vehicle Telematics System for Eco-Driving](https://www.tanchunsiong.com/2009/06/confero-building-a-vehicle-telematics-system-for-eco-driving/)
- GitHub: [@tanchunsiong](https://github.com/tanchunsiong)
- LinkedIn: [tanchunsiong](https://www.linkedin.com/in/tanchunsiong)
- X/Twitter: [@tanchunsiong](https://x.com/tanchunsiong)

---

*Final Year Project, Singapore Polytechnic Year 3, 2008-2009*
