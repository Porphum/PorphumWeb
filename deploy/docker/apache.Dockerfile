FROM ubuntu 
RUN apt update 
RUN apt install apache2 -y
RUN apt install apache2-utils -y 
RUN apt clean 
# RUN ufw allow 'Apache'
# RUN ufw status
# RUN sudo nano /etc/apache2/sites-available/your_domain.conf
WORKDIR /web
COPY [".", "/etc/apache2/sites-available"]
RUN mkdir /var/www/dotnet
RUN chown -R $USER:$USER /var/www/dotnet
RUN chmod -R 755 /var/www/dotnet
RUN a2ensite dotnet.conf
RUN a2dissite 000-default.conf
RUN a2enmod headers
RUN a2enmod proxy
RUN a2enmod ssl
RUN a2enmod proxy
RUN a2enmod proxy_balancer
RUN a2enmod proxy_http
RUN apache2ctl configtest
RUN service apache2 restart
EXPOSE 80
CMD ["apache2ctl", "-D", "FOREGROUND"]