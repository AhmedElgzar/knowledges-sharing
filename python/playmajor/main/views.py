from django.shortcuts import render
from django.http import HttpResponse, HttpRequest
from main.models import Track
from django.db.models import Q

def index(request):
    if request.method == 'POST':
        term = request.POST["term"]
        tracks = Track.objects.filter(Q(name__icontains=term)| Q(artist__icontains=term)).order_by('-rate')[:10]
        context = {'tracks': tracks, 'term': term}
    else:
        most_rated_tracks = Track.objects.all().order_by('-rate')[:10]
        context = {'tracks': most_rated_tracks}
    return render(request, 'index.html', context)